import { Card, CardRow, CardType } from "../types";

const formatCard = (card: CardRow): Card => {
  return {
    ...card,
    Type: CardType[card.Type],
    InternalTitle: card.Name.replace(/ /g, "_"),
    Comments: card.Comments?.replace(/\n/g, ". "),
  };
};

export default formatCard;
