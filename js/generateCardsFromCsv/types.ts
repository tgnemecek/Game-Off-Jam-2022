import Joi from "joi";

export enum CardType {
  Resource = 0,
  Unit = 10,
  Item = 20,
  Spell = 30,
  Building = 40,
}

export enum Resource {
  Wood = 0,
  Stone = 10,
}

export type CardRow = {
  id: number;
  type: CardType;
  title: string;
  description: string;
  image: string;
  woodCost?: string;
  stoneCost?: string;
};

export type Card = CardRow & { internalTitle?: string };

export type BuildCardOutput = {
  fileName: string;
  data: string;
};

export type BuildCardFn = (card: Card) => BuildCardOutput;

export type ValidateCardFn = (
  card: Card,
  customSchema?: Joi.SchemaMap
) => Promise<void>;
