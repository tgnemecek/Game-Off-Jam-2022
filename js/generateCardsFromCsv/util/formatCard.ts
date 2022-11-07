import { Card, CardRow } from "../types";

const formatCard = (card: CardRow) => {
  const formattedCard: Card = { ...card };
  formattedCard.internalTitle = formattedCard.title.replace(/ /g, "_");

  return formattedCard;
};

export default formatCard;
