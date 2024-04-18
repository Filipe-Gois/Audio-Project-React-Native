import styled, { css } from "styled-components";
import { Theme } from "../../Theme";

export const InputStyle = styled.TextInput.attrs((props) => ({
  placeholderTextColor: props.placeholderTextColor
    ? props.placeholderTextColor
    : "#BABABA",
}))`
  ${(props) =>
    props.fieldMinHeight &&
    css`
      min-height: ${props.fieldMinHeight};
    `}
  width: ${(props) => ` ${props.fieldWidth}%`};
  max-width: ${(props) => ` ${props.fieldMaxWidth}%`};
  height: ${(props) => ` ${props.fieldHeight}px`};
  color: ${(props) =>
    props.textColor ? props.textColor : Theme.colors.primary};
  border-radius: 20px;
  border: ${(props) =>
    props.border ? props.border : `2px solid ${Theme.colors.red.red1}`};
  background-color: ${(props) =>
    props.backGround ? props.backGround : "#fff"};
  font-size: 20px;
  padding: 16px;
  /* text-align: justify; */
  /* padding-bottom: ${(props) =>
    props.fieldPaddingBottom ? "80px" : "0px"}; */

  /* padding-bottom: 80px; */

  /* text-align: center; */
  ${(props) =>
    props.fieldTextAlign &&
    css`
      text-align: ${props.fieldTextAlign};
    `}
`;

export const InputVerification = styled(InputStyle)`
  width: 65px;
  height: 62px;
`;

export const InputMedicalRecord = styled(InputStyle)`
  width: 100%;
  height: 121px;
`;

export const InputCheckEmailStyle = styled(InputStyle)`
  text-align: center;
  font-size: 40px;
  padding: 5px 10px;
`;

export const InputSelectBox = styled.View`
  width: 100%;
  height: 55px;
  border: 2px solid ${Theme.colors.primary};
  border-radius: 5px;
`;
