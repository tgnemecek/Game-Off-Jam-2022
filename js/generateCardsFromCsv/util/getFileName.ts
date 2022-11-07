import { Card } from "../types";

const getFileName = (card: Card) => `Card_${card.internalTitle}`;

export default getFileName;
