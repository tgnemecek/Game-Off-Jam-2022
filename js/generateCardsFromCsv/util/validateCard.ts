import Joi from "joi";
import { CardType, Card, ValidateCardFn } from "../types";

const baseSchema: Joi.SchemaMap<Card> = {
  Id: Joi.number().positive().allow(0).required(),
  Type: Joi.number()
    .valid(...Object.values(CardType))
    .required(),
  TypeName: Joi.string().required(),
  Name: Joi.string().required(),
  InternalTitle: Joi.string().disallow(" ").required(),
  Description: Joi.string().optional().allow(""),
  WoodCost: Joi.number().positive().allow(0),
  FishCost: Joi.number().positive().allow(0),
  GoldCost: Joi.number().positive().allow(0),
  MaxHP: Joi.string().optional().allow(0),
  Comments: Joi.string().optional().allow(""),
};

const validateCard: ValidateCardFn = async (card, customSchema) => {
  const fullSchema = Joi.object({
    ...baseSchema,
    ...(customSchema ? customSchema : {}),
  });

  try {
    await fullSchema.validateAsync(card);
  } catch (err) {
    console.error(err);

    process.exit(0);
  }
};

export default validateCard;
