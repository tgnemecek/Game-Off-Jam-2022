import { Card, CardConstructorArgs } from "../types";

const CardConstructor = new Map([
  ["title", "string"],
  ["woodCost", "int"],
  ["stoneCost", "int"],
]);

const buildConstructor = (card: Card, args: CardConstructorArgs) => {
  const entries = Array.from(CardConstructor.entries());

  const formattedArgs = entries.map(([fieldName, fieldType], index) => {
    if (fieldType === "string") return `"${args[index]}"`;
    if (fieldType === "int") return Number(args[index]) || 0;
    return args[index];
  });

  const propertiesName = `${card.internalTitle}_Properties`;

  const propertiesClass = `public class ${propertiesName}
{
  ${entries
    .map(
      ([fieldName, fieldType], index) =>
        `public static ${fieldType} __${fieldName}__ = ${formattedArgs[index]};`
    )
    .join("\n\t")}
}`;

  const baseConstructorString = `${entries
    .map(([fieldName]) => `${propertiesName}.__${fieldName}__`)
    .join(",\n\t\t")}`;

  return { propertiesClass, baseConstructorString };
};

export default buildConstructor;
