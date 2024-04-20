import React, { useEffect, useState } from "react";
import {
  Container,
  ContainerBoxStyle,
  FormBox,
  MainContent,
  MainContentScroll,
} from "../../Components/Container/style";
import { Text, View } from "react-native";
import { Input } from "../../Components/Input/index";
import { Button } from "../../Components/Button/style";
import { Title } from "../../Components/Title/style";
import { Theme } from "../../Theme";

import { AntDesign } from "@expo/vector-icons";
import { ActionButton } from "../../Components/Button";
import api, {
  falaParaTextoSource,
  textoParaFalaSource,
} from "../../Services/Service";
import ToggleButton from "../../Components/Toggle/Toggle";

const HomeScreen = () => {
  //false: exibe o formulario de inserir audio. True: exibe o formulario de exibir texto
  const [textForm, setTextForm] = useState(false);

  const [Audio, setAudio] = useState(null);
  const [texto, setTexto] = useState(null);

  const audioToText = async () => {
    try {
      const response = await api.post(falaParaTextoSource, {});
    } catch (error) {
      console.log(error);
    }
  };

  const textToAudio = async () => {
    try {
      const response = await api.post(textoParaFalaSource, {});
    } catch (error) {
      console.log(error);
    }
  };

  useEffect(() => {
    return (cleanUp = () => {});
  }, []);

  return (
    <Container>
      <MainContentScroll>
        <MainContent>
          <FormBox margin={"30px 0 0 0"}>
            <ContainerBoxStyle
              fieldJustifyContent={"center"}
              fieldAlignItems={"center"}
            >

              <ToggleButton/>
              <Input
                fieldHeight={200}
                fieldWidth={100}
                placeholder={"Áudio Convertido:"}
              />

              <Button background={Theme.colors.red.red3}>
                <Title>Salvar áudio</Title>
              </Button>
            </ContainerBoxStyle>
            <ContainerBoxStyle
              fieldJustifyContent={"center"}
              fieldAlignItems={"center"}
            >
              <ActionButton pressable={() => console.log("dsfdsf")} />
            </ContainerBoxStyle>
          </FormBox>
        </MainContent>
      </MainContentScroll>
    </Container>
  );
};

export default HomeScreen;
