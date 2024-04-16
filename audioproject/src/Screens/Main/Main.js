import React from "react";
import { createBottomTabNavigator } from "@react-navigation/bottom-tabs";
const BottomTab = createBottomTabNavigator();

const Main = () => {
  return (
    <BottomTab.Navigator
      initialRouteName="HomeScreen"
      screenOptions={({ route }) => ({
        tabBarStyle: {
          backgroundColor: Theme.colors.whiteColor,
          height: 60,
          paddingTop: 10,
        },
        tabBarActiveBackgroundColor: "transparent",
        tabBarShowLabel: false,
        headerShown: false,
        tabBarIcon: ({ focused }) => {
          if (route.name === "HomeScreen") {
            return (
              <MainContentIcon
                tabBarActiveBackgroundColor={
                  focused ? "#ecf2ff" : "transparent"
                }
              >
                <FontAwesome
                  name="calendar"
                  size={18}
                  color={focused ? Theme.colors.secondary : Theme.colors.grayV2}
                />

                {focused && (
                  <TextIcon
                    colorText={
                      focused ? Theme.colors.secondary : Theme.colors.grayV2
                    }
                  >
                    Agenda
                  </TextIcon>
                )}
              </MainContentIcon>
            );
          } else {
            return (
              <MainContentIcon
                fieldFlexDirection={"row-reverse"}
                tabBarActiveBackgroundColor={
                  focused ? "#ecf2ff" : "transparent"
                }
              >
                <FontAwesome
                  name="user-circle"
                  size={18}
                  color={focused ? Theme.colors.secondary : Theme.colors.grayV2}
                />

                {focused && (
                  <TextIcon
                    colorText={
                      focused ? Theme.colors.secondary : Theme.colors.grayV2
                    }
                  >
                    Perfil
                  </TextIcon>
                )}
              </MainContentIcon>
            );
          }
        },
      })}
    ></BottomTab.Navigator>
  );
};

export default Main;
