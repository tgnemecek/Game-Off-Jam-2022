import { Card } from "../types";

const CardProperties = new Map<keyof Card, string>();
CardProperties.set("Id", "int");
CardProperties.set("Name", "string");
CardProperties.set("Description", "string");
CardProperties.set("Image", "string");
CardProperties.set("WoodCost", "int");
CardProperties.set("FishCost", "int");
CardProperties.set("GoldCost", "int");

const buildConstructor = (card: Card) => {
  const entries = Array.from(CardProperties.entries());

  const formattedArgs = entries.map(([fieldName, fieldType]) => {
    if (fieldType === "string") return `"${card[fieldName]}"`;
    if (fieldType === "int") return Number(card[fieldName]) || 0;
    return card[fieldName];
  });

  const properties = `${entries
    .map(([fieldName], index) => `this.${fieldName} = ${formattedArgs[index]};`)
    .join("\n\t\t")}`;
  return properties;
};

export default buildConstructor;
