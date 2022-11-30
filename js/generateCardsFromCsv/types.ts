import Joi from "joi";

export enum CardType {
  Resource = 0,
  Unit = 10,
  Item = 20,
  Spell = 30,
  Building = 40,
}

// TODO: Autogenerate
export type CardTypeString =
  | "Resource"
  | "Unit"
  | "Item"
  | "Spell"
  | "Building";

export enum Resource {
  Wood = 0,
  Fish = 10,
  Gold = 20
}

export type CardRow = {
  Id: number;
  Type: CardTypeString;
  Name: string;
  Description: string;
  Image: string;
  WoodCost: string;
  FishCost: string;
  GoldCost: string;
  MaxHP: number;
  Comments?: string;
};

export type Card = Omit<CardRow, "Type"> & {
  Type: CardType;
  InternalTitle?: string;
  TypeName: CardTypeString;
};

export type BuildCardOutput = string;

export type BuildCardFn = (card: Card) => BuildCardOutput;

export type ValidateCardFn = (
  card: Card,
  customSchema?: Joi.SchemaMap
) => Promise<void>;
