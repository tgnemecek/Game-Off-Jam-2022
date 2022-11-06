import Joi from "joi";
import { CardRow, CardType, ValidateCardFn } from "../types";

const idMap: Record<string, true> = {};

const baseSchema: Joi.SchemaMap = {
  id: Joi.number().positive().allow(0).required(),
  type: Joi.number()
    .valid(...Object.values(CardType))
    .required(),
  title: Joi.string().required(),
  internalTitle: Joi.string().disallow(" ").required(),
  description: Joi.string(),
  image: Joi.string(), // not sure how images will be handled
  woodCost: Joi.number().positive().allow(0),
  stoneCost: Joi.number().positive().allow(0),
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
