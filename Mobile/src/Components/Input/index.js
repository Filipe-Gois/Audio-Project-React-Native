import React from "react";
import { InputCheckEmailStyle, InputSelectBox, InputStyle } from "./style";
import { StyleSheet, View } from "react-native";
// import RNPickerSelect from "react-native-picker-select";

// import { FontAwesomeIcon } from "@fortawesome/react-native-fontawesome";
// import { faCaretDown } from "@fortawesome/free-solid-svg-icons";
// import { FontAwesome } from "@expo/vector-icons";

export const Input = ({
  placeholder,
  fieldValue,
  onChangeText,
  keyType,
  maxLength,
  onEndEditing,
  fieldWidth = 100,
  fieldMaxWidth = 100,
  fieldHeight = 55,
  backGround = "",
  border = "",
  placeholderTextColor,
  fieldPaddingBottom,
  textColor,
  fieldTextAlign,
  fieldMinHeight,
  secureTextEntry = false,
  autoFocus,
}) => {
  return (
    <InputStyle
      secureTextEntry={secureTextEntry}
      fieldMinHeight={fieldMinHeight}
      fieldWidth={fieldWidth}
      textColor={textColor}
      fieldMaxWidth={fieldMaxWidth}
      fieldHeight={fieldHeight}
      placeholder={placeholder}
      value={fieldValue}
      onChangeText={onChangeText}
      keyboardType={keyType}
      maxLength={maxLength}
      onEndEditing={onEndEditing}
      border={border}
      backGround={backGround}
      placeholderTextColor={placeholderTextColor}
      fieldPaddingBottom={fieldPaddingBottom}
      fieldTextAlign={fieldTextAlign}
      multiline={true}
      numberOfLines={4}
      autoFocus={autoFocus}
    />
  );
};

