import { Card, CardRow } from "../types";

const formatCard = (card: CardRow) => {
  const formattedCard: Card = { ...card };
  formattedCard.InternalTitle = formattedCard.Name.replace(/ /g, "_");

  return formattedCard;
};

export default formatCard;
