import React, {Component} from 'react';

import {
  StyleSheet,
  Text,
  TouchableOpacity,
  View,
  Image,
  ImageBackground,
  TextInput,
} from 'react-native';

import AsyncStorage from '@react-native-async-storage/async-storage';

import api from '../services/api';

export default class Login extends Component {
  constructor(props) {
    super(props);
    this.state = {
      email: '',
      senha: '',
    };
  }

  realizarLogin = async () => {

    try {
      
      const resposta = await api.post('/login', {
        email: this.state.email, 
        senha: this.state.senha, 
      });

      if (resposta.status == 200) {
        
        const token = resposta.data.token;
        await AsyncStorage.setItem('userToken', token);
        this.props.navigation.navigate('Consultas');
        console.warn(token);
      }
    }
    catch (error) {
    }

  };

  render() {
    return (
      <ImageBackground
        source={require('../../assets/img/img.png')}
        style={StyleSheet.absoluteFillObject}>
        <View style={styles.overlay} />
        <View style={styles.main}>
          <View style={styles.div}> 
            <View style={styles.placeImg}>
              <Image
                source={require('../../assets/img/logo.png')}
                style={styles.mainImgLogin}
            />
            </View>
            <TextInput
              style={styles.inputLogin}
              placeholder="E-mail"
              placeholderTextColor="#FFF"
              keyboardType="email-address"
              // ENVENTO PARA FAZERMOS ALGO ENQUANTO O TEXTO MUDA
              onChangeText={email => this.setState({email})}
            />
            <TextInput
              style={styles.inputLogin}
              placeholder="Senha"
              placeholderTextColor="#FFF"
              keyboardType="default" //para default nao obrigatorio.
              secureTextEntry={true} //proteje a senha.
              // ENVENTO PARA FAZERMOS ALGO ENQUANTO O TEXTO MUDA
              onChangeText={senha => this.setState({senha})}
            />
            <TouchableOpacity
              style={styles.btnLogin}
              onPress={this.realizarLogin}>
              <Text style={styles.btnLoginText}>Login</Text>
            </TouchableOpacity>
          </View>
        </View>
      </ImageBackground>
    );
  }
}

const styles = StyleSheet.create({
  
  //antes da main
  overlay: {
    ...StyleSheet.absoluteFillObject, 
    backgroundColor: 'rgba(0, 0, 0, 0.2)'
  },

  main: {
    justifyContent: 'center',
    alignItems: 'center',
    width: '100%',
    height: '100%',
  },
  
  div: {
    height: 470,
    width: 320,
    borderWidth: 4,
    borderRadius: 10,
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: 'rgba(0, 0, 0, 0.15)',
    borderColor: 'rgba(255, 255, 255, 0.1)'
  },

  mainImgLogin: {
    height: 100, 
    width: 90, 
    margin: 60, 
    marginTop: 60, 
    justifyContent: 'center',
    alignItems: 'center',
  },

  // placeImg: {
  //   height: 120, 
  //   width: 120, 
  //   margin: 60, 
  //   marginTop: 0, 
  //   justifyContent: 'center',
  //   alignItems: 'center',
  //   borderRadius: 60,
  //   backgroundColor: 'rgba(255, 255, 255, 1)'
  // },

  inputLogin: {
    width: 240, 
    marginTop: 0,
    marginBottom: 40,
    fontSize: 20,
    letterSpacing: 3,
    color: '#FFFFFF',
    borderBottomColor: '#FFF', 
    borderBottomWidth: 2, 
  },

  btnLoginText: {
    fontSize: 12, 
    fontFamily: 'Open Sans Light', 
    color: '#1AD9A3', 
    letterSpacing: 6, 
    textTransform: 'uppercase', 
  },
  btnLogin: {
    alignItems: 'center',
    justifyContent: 'center',
    height: 40,
    width: 240,
    backgroundColor: '#FFFFFF',
    borderColor: '#FFFFFF',
    borderRadius: 6,
    shadowOffset: {height: 1, width: 1},
  },
});