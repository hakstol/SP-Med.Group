import React, {Component} from 'react';

import {
  StyleSheet,
  Text,
  Image,
  View,
} from 'react-native';

import AsyncStorage from '@react-native-async-storage/async-storage';

import api from './consultas';

export default class Login extends Component {
  constructor(props) {
    super(props);
    this.state = {
      email: '',
      senha: '',
    };
  }
  //como vamos trabalhar com assync historage,
  //nossa funcao tem que ser async.
  realizarLogin = async () => {
    //nao temos mais  console log.
    //vamos utilizar console.warn.

    //apenas para teste.
    console.warn(this.state.email + ' ' + this.state.senha);

    const resposta = await api.post('/login', {
      email: this.state.email, //ADM@ADM.COM
      senha: this.state.senha, //senha123
    });

    //mostrar no swagger para montar.
    const token = resposta.data.token;
    await AsyncStorage.setItem('userToken', token);

    //agora sim podemos descomentar.
    if (resposta.status == 200) {
      this.props.navigation.navigate('Consultas');
    }

    console.warn(token);

    //
  };

  render() {
    return (
       <View style={styles.view}></View>
    )
  }
}

const styles = StyleSheet.create({
  
  view: {
    height: '100%',
    with: '100%',
    backgroundColor: 'blue'
  }
});