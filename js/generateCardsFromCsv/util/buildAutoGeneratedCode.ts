import { AUTO_GENERATED } from "../constants";
import { CardType, Card } from "../types";
import buildConstructor from "./buildConstructor";
import getFileName from "./getFileName";

const CardTypeLabelMap: Record<CardType, string> = {
  [CardType.Resource]: "Resource",
  [CardType.Unit]: "Unit",
  [CardType.Item]: "Item",
  [CardType.Spell]: "Spell",
  [CardType.Building]: "Building",
};

const AUTO_GENERATED_TEXT = `
#region ${AUTO_GENERATED}
// Do not manually change code within the AUTO-GENERATED region. Instead update the Card Library spreadsheet and run npm build-cards`.trim();

export const buildAutoGeneratedCode = (card: Card) => {
  const { title, woodCost, stoneCost } = card;

  const TYPE_NAME = CardTypeLabelMap[card.type];

  const fileName = getFileName(card);

  const { propertiesClass, baseConstructorString } = buildConstructor(card, [
    title,
    woodCost,
    stoneCost,
  ]);

  return `
  ${AUTO_GENERATED_TEXT}
  ${propertiesClass}
  
public class ${fileName} : Card_${TYPE_NAME}
{
  public ${fileName}() : base(
    ${baseConstructorString}
  )
  { }
`.trim();
};