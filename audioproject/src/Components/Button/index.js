import { ActivityIndicator, Image } from "react-native";
import {
  ButtonTextStyle,
  ButtonTitle,
  ButtonTitleGoogle,
  ContainerButton,
} from "../Button/style";
import {
  ButtonAquaStyle,
  ButtonAsyncStyle,
  ButtonGoogle,
  ButtonTabStyle,
} from "./style";
import { MaterialIcons } from "@expo/vector-icons";
import { Theme } from "../../Theme";
import { AntDesign } from "@expo/vector-icons";
import { FontAwesome } from "@expo/vector-icons";

export const ButtonGoogleComponent = () => {
  return (
    <ButtonGoogle>
      <ButtonTitleGoogle>Entrar com Google</ButtonTitleGoogle>
    </ButtonGoogle>
  );
};

export const ButtonListAppontment = ({
  textButton,
  clickButton = false,
  onPress,
  children,
  fieldWidth,
}) => {
  return (
    <ButtonTabStyle
      fieldWidth={fieldWidth}
      clickButton={clickButton}
      onPress={onPress}
    >
      {/* <ButtonTextStyle clickButton={clickButton}>{textButton}</ButtonTextStyle> */}
      {children}
    </ButtonTabStyle>
  );
};

export const ButtonAqua = ({ onPress }) => {
  return (
    <ButtonAquaStyle onPress={onPress}>
      <MaterialIcons name="add-a-photo" size={20} color="white" />
      <ButtonTitle>Enviar</ButtonTitle>
    </ButtonAquaStyle>
  );
};

//botão utilizado em requisições de api. Tem as seguintes validações: exibe um componente de loading ao processar requisição e trava o botão ao realizar uma requisição
export const ButtonAsync = ({
  textButton,
  loading = false,
  onPress,
  disabled = false,
  sizeActivityIndicator = 20,
  colorsizeActivityIndicator = Theme.colors.whiteColor,
}) => {
  return (
    <ButtonAsyncStyle disabled={disabled} onPress={onPress}>
      {loading ? (
        <ActivityIndicator
          size={sizeActivityIndicator}
          color={colorsizeActivityIndicator}
        />
      ) : (
        <ButtonTitle>{textButton}</ButtonTitle>
      )}
    </ButtonAsyncStyle>
  );
};

export const ActionButton = ({ pressable, speek = true }) => {
  return (
    <ContainerButton speek={speek} pressable={pressable}>
      {speek ? (
        <FontAwesome name="microphone" size={30} color="black" />
      ) : (
        <AntDesign name="sound" size={30} color="black" />
      )}
    </ContainerButton>
  );
};
