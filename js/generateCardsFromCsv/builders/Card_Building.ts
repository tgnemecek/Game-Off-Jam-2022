import Joi from "joi";
import { BuildCardFn, ValidateCardFn } from "../types";
import baseBuilder from "./BaseBuilder";
import validateCard from "../util/validateCard";

const validate: ValidateCardFn = async (card) => {
  const customSchema: Joi.SchemaMap = {};

  validateCard(card, customSchema);
};

const buildOutput: BuildCardFn = (card) => baseBuilder(card);

export default { validate, buildOutput };
