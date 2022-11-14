import { CUSTOM_CODE_START } from "../constants";
import { BuildCardFn } from "../types";
import { buildAutoGeneratedCode } from "../util/buildAutoGeneratedCode";

const baseBuilder: BuildCardFn = (card) => {
  const autoGeneratedCode = buildAutoGeneratedCode(card);

  const data = `
  ${autoGeneratedCode}

  ${CUSTOM_CODE_START}
  
  public override void Play()
  {
    // TODO: Add logic
  }

  public override void EndOfTurn()
  {
    // TODO: Add logic
  }
}
`.trim();

  return data;
};

export default baseBuilder;