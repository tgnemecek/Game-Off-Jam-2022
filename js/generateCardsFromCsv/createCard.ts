import { Card } from "./types";
import fs from "fs";
import { buildCardOutput } from "./builders";

const createCard = (card: Card, cardPath: string) => {
  const data = buildCardOutput(card);

  return fs.writeFileSync(cardPath, data);
};

export default createCard;
