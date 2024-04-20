import React, { useState } from "react";
import { View, Text, TouchableOpacity, StyleSheet } from "react-native";
import { Theme } from "../../Theme";

const ToggleButton = () => {
  const [isOn, setIsOn] = useState(false);

  const toggleSwitch = () => {
    setIsOn(!isOn);
  };

  return (
    <View style={styles.toggleButtonCover}>
      <TouchableOpacity
        style={[styles.button, isOn ? styles.buttonOn : styles.buttonOff]}
        onPress={toggleSwitch}
      >
        <Text style={styles.knobText}>{isOn ? "NO" : "YES"}</Text>
      </TouchableOpacity>
    </View>
  );
};

const styles = StyleSheet.create({
  toggleButtonCover: {
    display: "flex",
    justifyContent: "center",
    alignItems: "center",
    width: "auto",
    height: "auto",
    backgroundColor: "#fff",
    borderRadius: 100,
    // shadowColor: "#000",
    // shadowOffset: { width: 0, height: 2 },
    // shadowOpacity: 0.25,
    // shadowRadius: 3.84,
    // elevation: 5,
  },
  button: {
    width: 74,
    height: 36,
    borderRadius: 100,
    justifyContent: "center",
    alignItems: "center",
  },
  buttonOn: {
    backgroundColor: Theme.colors.green.green1,
  },
  buttonOff: {
    backgroundColor: Theme.colors.red.red1,
  },
  knobText: {
    color: "#fff",
    fontWeight: "bold",
  },
});

export default ToggleButton;
