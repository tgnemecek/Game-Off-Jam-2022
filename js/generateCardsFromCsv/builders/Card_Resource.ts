import Joi from "joi";
import { BuildCardFn, ValidateCardFn } from "../types";
import validateCard from "./validateCard";

const validate: ValidateCardFn = async (card) => {
  const customSchema: Joi.SchemaMap = {};

  validateCard(card, customSchema);
};

const buildOutput: BuildCardFn = (card) => {
  const TYPE_NAME = "Resource";

  const { title, woodCost, stoneCost, internalTitle } = card;

  const buildBaseConstructor = () => `"${title}", ${woodCost}, ${stoneCost}`;

  const fileName = `Card_${internalTitle}`;

  const data = `
public class ${fileName} : Card_${TYPE_NAME}
{
public ${fileName}() : base(${buildBaseConstructor()}) { }

public override void Play()
{
  // TODO: Add logic
}
} 
`.trim();

  return { fileName, data };
};

export default { validate, buildOutput };
