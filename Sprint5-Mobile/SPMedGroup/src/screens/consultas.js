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
        <View style={styles.header}>
  
        </View>

        <View style={styles.section1}>
            <Text style={styles.text1}>Consultas agendadas</Text>
            <View style={styles.line1}></View>
            <Text style={styles.text3}>◼ Data - Especialidade - Paciente</Text>
        </View>

        <View style={styles.section2}>
            <Text style={styles.text2}>Consultas realizadas</Text>
            <View style={styles.line2}></View>
            <Text style={styles.text4}>◼ Data - Especialidade - Paciente</Text>
        </View>
      </View>
    );
  };
}

const styles = StyleSheet.create({
  main: {
    flex: 1
  },

  //header
  header: {
    margin: 0,
    padding: 0,
    width: '100%',
    height: 65,
    borderWidth: 4,
    borderColor: '#1AD9A3'
  },

  headerImg: {
    height: 34,
    width: 39
  },

  //section1
  section1: {
    height: 250,
    width: 360,
    marginTop: 60,
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
    borderBottomWidth: 2,
    borderBottomColor: '#1AD9A3',
  },

  text3: {
    paddingTop: 10,
    fontFamily: 'Actor',
    fontSize: 15
  },

  //section 2
  section2: {
    height: 250,
    width: 360,
    marginTop: 10,
    marginLeft: 10,
  },

  text2: {
  fontSize: 25,
  fontFamily: 'Cambria',
  color: 'black',
  },

  line2: {
  width: 360,
  marginTop: 10,
  borderBottomColor: '#1AD9A3',
  borderBottomWidth: 2
  },

  text4: {
    paddingTop: 10,
    fontFamily: 'Actor',
    fontSize: 15
  }
});