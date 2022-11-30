import upperCamelCase  from 'uppercamelcase';
import { Card, CardRow, CardType } from "../types";

const BASE_IMAGE_PATH = "Card";

const formatCard = (card: CardRow): Card => {
  const InternalTitle = upperCamelCase(card.Name.replace(/'/g, ""))

  return {
    ...card,
    Type: CardType[card.Type],
    TypeName: card.Type,
    InternalTitle,
    Image: `${BASE_IMAGE_PATH}/${card.Type}/${InternalTitle}`
  };
};

export default formatCard;
