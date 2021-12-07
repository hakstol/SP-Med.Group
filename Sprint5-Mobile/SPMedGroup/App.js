import { BackgroundColor } from 'chalk';
import React, { Component } from 'react';
import {
  StyleSheet,
  Text,
  View,
} from 'react-native';


export default class App extends Component{
  render(){
    return (
      <View style={styles.main}>
        <View style={styles.title1}>
          <Text style={styles.text1}>Consultas agendadas</Text>
          <View style={styles.line1}></View>
        </View>
      </View>
    );
  };
}

const styles = StyleSheet.create({
  main: {
    flex: 1,
    backgroundColor: '#f1f1f1',
  },

  title1: {
    flex: 1,
    backgroundColor: '#fff',
    width: 360,
    marginTop: 65,
    marginLeft: 10,
  },

  text1: {
    fontSize: 25,
    fontFamily: 'Cambria',
    color: 'black',
  },

  line1: {
    width: 360,
    marginTop: 10,
    borderBottomColor: '#1AD9A3',
    borderBottomWidth: 2
  }
});
