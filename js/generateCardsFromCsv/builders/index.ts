import { BuildCardFn, CardType, ValidateCardFn } from "../types";

import { default as ResourceCard } from "./Card_Resource";
import { default as ItemCard } from "./Card_Item";
import { default as SpellCard } from "./Card_Spell";
import { default as UnitCard } from "./Card_Unit";
import { default as BuildingCard } from "./Card_Building";

const CardBuilderMap: Record<
  CardType,
  { validate: ValidateCardFn; buildOutput: BuildCardFn }
> = {
  [CardType.Resource]: ResourceCard,
  [CardType.Unit]: UnitCard,
  [CardType.Item]: ItemCard,
  [CardType.Spell]: SpellCard,
  [CardType.Building]: BuildingCard,
};

const buildCardOutput: BuildCardFn = (card) =>
  CardBuilderMap[card.type].buildOutput(card);

const validateCard: ValidateCardFn = (card) =>
  CardBuilderMap[card.type].validate(card);

export { buildCardOutput, validateCard };
