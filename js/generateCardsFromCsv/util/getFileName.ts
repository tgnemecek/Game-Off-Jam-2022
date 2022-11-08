import { Card } from "../types";

const getFileName = (card: Card) => `Card_${card.InternalTitle}`;

export default getFileName;
