import fs from "fs";
import path from "path";
import * as csv from "fast-csv";
import { Card, CardType } from "./types";
import { buildCardOutput, validateCard } from "./builders";
import formatCard from "./builders/formatCard";

const CSV_PATH = path.join(__dirname, "./input.csv");
const CARD_LIBRARY_PATH = path.join(
  __dirname,
  "../..",
  "Assets/Prefabs/Card/CardLibrary"
);

type CardRow = {
  type: CardType;
  id: number;
  title: string;
  description: string;
  image: string;
  woodCost?: string;
  stoneCost?: string;
};

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
        cards.push(formatCard(row));
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
    const { fileName, data } = buildCardOutput(card);

    fs.writeFileSync(`${CARD_LIBRARY_PATH}/${fileName}.cs`, data);
  }
};

generateCardsFromCsv();
