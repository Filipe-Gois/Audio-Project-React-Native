import React from "react";
import { CheckboxContainer } from "./Style";

const CheckBox = ({ value, onValueChange }) => {
  return (
    <CheckboxContainer
      value={value}
      onValueChange={onValueChange}
    ></CheckboxContainer>
  );
};

export default CheckBox;
