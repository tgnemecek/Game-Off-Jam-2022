import { START_HERE_TEXT } from "../constants";
import { BuildCardFn } from "../types";
import { buildAutoGeneratedCode } from "../util/buildAutoGeneratedCode";

const baseBuilder: BuildCardFn = (card) => {
  const autoGeneratedCode = buildAutoGeneratedCode(card);

  const data = `
  ${autoGeneratedCode}

  ${START_HERE_TEXT}
  public override void Play()
  {
    // TODO: Add logic
  }
}
`.trim();

  return data;
};

export default baseBuilder;
