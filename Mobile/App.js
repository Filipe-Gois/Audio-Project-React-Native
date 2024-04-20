import { NavigationContainer } from "@react-navigation/native";
import { createNativeStackNavigator } from "@react-navigation/native-stack";
import { useFonts, Poppins_400Regular } from "@expo-google-fonts/poppins";
import HomeScreen from "./src/Screens/HomeScreen/HomeScreen";

import React from "react";
import { Container, MainContent } from "./src/Components/Container/style";

const App = () => {
  const Stack = createNativeStackNavigator();
  let [fontsLoaded, fontError] = useFonts({
    Poppins_400Regular,
  });

  if (!fontsLoaded && !fontError) {
    return null;
  }

  return (
    // <Container>
    <HomeScreen />
    // </Container>
  );
};

export default App;
