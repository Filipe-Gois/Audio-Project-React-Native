import { NavigationContainer } from "@react-navigation/native";
import { createNativeStackNavigator } from "@react-navigation/native-stack";
import { useFonts, Poppins_400Regular } from "@expo-google-fonts/poppins";

export default function App() {
  const Stack = createNativeStackNavigator();

  let [fontsLoaded, fontError] = useFonts({
    Poppins_400Regular,
  });

  if (!fontsLoaded && !fontError) {
    return null;
  }

  return (
    <NavigationContainer>
      <Stack.Navigator>
        <Stack.Screen />
      </Stack.Navigator>
    </NavigationContainer>
  );
}
