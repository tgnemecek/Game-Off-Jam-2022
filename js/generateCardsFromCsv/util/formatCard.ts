import upperCamelCase  from 'uppercamelcase';
import { Card, CardRow, CardType } from "../types";

const formatCard = (card: CardRow): Card => {
  return {
    ...card,
    Type: CardType[card.Type],
    TypeName: card.Type,
    InternalTitle: upperCamelCase(card.Name.replace(/'/g, "")),
    Comments: card.Comments?.replace(/\n/g, ". "),
  };
};

export default formatCard;
