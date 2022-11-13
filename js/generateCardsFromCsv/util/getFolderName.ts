import { Card } from "../types";

const getFolderName = (card: Card) => `${card.TypeName}CardLibrary`;

export default getFolderName;
