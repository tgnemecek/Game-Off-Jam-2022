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
  Id: number;
  Type: CardType;
  Name: string;
  Description: string;
  Image: string;
  WoodCost: string;
  StoneCost: string;
};

export type Card = CardRow & {
  InternalTitle?: string;
};

export type BuildCardOutput = string;

export type BuildCardFn = (card: Card) => BuildCardOutput;

export type ValidateCardFn = (
  card: Card,
  customSchema?: Joi.SchemaMap
) => Promise<void>;
