import Joi from "joi";
import { CardType, ValidateCardFn } from "../types";

const baseSchema: Joi.SchemaMap = {
  Id: Joi.number().positive().allow(0).required(),
  Type: Joi.number()
    .valid(...Object.values(CardType))
    .required(),
  TypeName: Joi.string().required(),
  Name: Joi.string().required(),
  InternalTitle: Joi.string().disallow(" ").required(),
  Description: Joi.string().optional().allow(""),
  Image: Joi.string().optional().allow(""), // not sure how images will be handled
  WoodCost: Joi.number().positive().allow(0),
  StoneCost: Joi.number().positive().allow(0),
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
