import fs from "fs";
import path from "path";
import chalk from "chalk";
import * as csv from "fast-csv";
import { Card, CardRow } from "./types";
import { validateCard } from "./builders";
import formatCard from "./util/formatCard";
import updateCard from "./updateCard";
import getFileName from "./util/getFileName";
import createCard from "./createCard";
import getFolderName from "./util/getFolderName";

const CSV_PATH = path.join(__dirname, "./input.csv");
const BASE_CARD_LIBRARY_PATH = path.join(
  __dirname,
  "../..",
  "Assets/Prefabs/Card/CardLibrary"
);

const generateCardsFromCsv = async () => {
  const cards: Card[] = [];

  await new Promise((resolve) => {
    csv
      .parseFile(CSV_PATH, {
        headers: true,
      })
      .on("error", (error) => {
        console.error(error);
        process.exit(0);
      })
      .on("data", (row: CardRow) => {
        if (!row.Type)
          console.log(
            chalk.red(
              `Could not add card with id: ${row.Id} due to missing Type`
            )
          );
        else {
          const formatted = formatCard(row);
          console.log({ formatted });
          cards.push(formatted);
        }
      })
      .on("end", () => {
        resolve(null);
      });
  });

  // Validate before building
  for (const card of cards) {
    await validateCard(card);
  }

  // Build cards and write to card library
  for (const card of cards) {
    const fileName = getFileName(card);
    const folderName = getFolderName(card);

    const cardPath = path.normalize(`${BASE_CARD_LIBRARY_PATH}/${folderName}/${fileName}.cs`);

    if (fs.existsSync(cardPath)) updateCard(card, cardPath);
    else createCard(card, cardPath);
  }
};

generateCardsFromCsv();
