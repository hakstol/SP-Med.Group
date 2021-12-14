import React, { Component } from 'react';

import { View, Text, StyleSheet, FlatList } from 'react-native';


export default class App extends Component{
  constructor(props) {
    super(props);
    this.state = {
        listaConsulta: []
    };
}


buscarConsulta = async () => {
    
  const token = await AsyncStorage.getItem('userToken')

    try {
        const token = await AsyncStorage.getItem('userToken');

        if (token != null) {
            const resposta = await api('/Consulta', {
                headers: {
                    Authorization: 'Bearer ' + token,
                },
            });

            if (resposta.status == 200) {
                this.setState({ listaConsulta: resposta.data });
            }
        }
    }
    catch (error) {
        console.warn(error);
    }
};

componentDidMount() {
    this.buscarConsulta();
}

render() {
  return (
      <View style={styles.main}>
          <View style={styles.containerTitle}>
              <Text style={styles.title}>Minhas Consultas</Text>
          </View>

          <View style={styles.containerList}>
              <FlatList
                  contentContainerStyle={styles.mainBodyList}
                  data={this.state.listaConsultas}
                  keyExtractor={item => item.idConsulta}
                  renderItem={this.renderItem}
              />
          </View>
      </View>

  )
}

renderItem = ({ item }) => (
  <View style={styles.flatItemRow}>
      <View style={styles.flatItemContentRow}>
          <Text style={styles.itemTitle}>Nome do paciente:</Text>
          <Text style={styles.flatItemContent}>{item.idPacienteNavigation.idUsuarioNavigation.nomeUsuario}</Text>
      </View>

      <View style={styles.flatItemContentRow}>
          <Text style={styles.itemTitle}>Nome do Médico:</Text>
          <Text style={styles.flatItemContent}>{item.idMedicoNavigation.idUsuarioNavigation.nomeUsuario}</Text>
      </View>

      <View style={styles.flatItemContentRow}>
          <Text style={styles.itemTitle}>Data da Consulta:</Text>
          <Text style={styles.flatItemContent}>{Intl.DateTimeFormat("pt-BR",{
              year: 'numeric', month: 'short', day: 'numeric', hour: 'numeric', minute: 'numeric'
          }).format(new Date(item.dataConsulta))}</Text>
      </View>
      <View style={styles.flatItemContentRow}>
          <Text style={styles.itemTitle}>Descrição da Consulta:</Text>
          <Text style={styles.flatItemContent}>{item.descricaoConsulta}</Text>
      </View>
      
  </View>
)
}

const styles = StyleSheet.create({
  // main: {
  //   flex: 1
  // },

  //header
  // header: {
  //   margin: 0,
  //   padding: 0,
  //   width: '100%',
  //   height: 65,
  //   borderWidth: 4,
  //   borderColor: '#1AD9A3',
  //   alignItems: 'center',
  //   justifyContent: 'center'
  // },

  // headerImg: {
  //   height: 50,
  //   width: 50,
  // },

  // //section1
  // section1: {
  //   height: 250,
  //   width: 360,
  //   marginTop: 100,
  //   marginLeft: 10,
  // },

  // text1: {
  //   fontSize: 25,
  //   fontFamily: 'Open Sans Light',
  //   color: 'black',
  // },

  // line1: {
  //   width: 360,
  //   marginTop: 10,
  //   borderBottomWidth: 2,
  //   borderBottomColor: '#1AD9A3',
  // },

  // text3: {
  //   paddingTop: 15,
  //   paddingLeft: 5,
  //   fontSize: 15,
  //   letterSpacing: 2,
  //   fontFamily: 'Open Sans Light'
  // },

  // //section 2
  // section2: {
  //   height: 250,
  //   width: 360,
  //   marginTop: 10,
  //   marginLeft: 10
  // },

  // text2: {
  // fontSize: 25,
  // fontFamily: 'Open Sans Light',
  // color: 'black'
  // },

  // line2: {
  // width: 360,
  // marginTop: 10,
  // borderBottomWidth: 2,
  // borderBottomColor: '#1AD9A3'
  // },

  // text4: {
  //   paddingTop: 15,
  //   paddingLeft: 5,
  //   fontSize: 15,
  //   letterSpacing: 2,
  //   fontFamily: 'Open Sans Light'
  // },

  main:{
    flex: 1
},
mainBodyList:{
    
},
containerTitle: {
   height: 80,
    alignItems: 'center',
    justifyContent: 'center',

},
title: {
    fontFamily: 'Roboto-Black',
    fontSize: 23,
    color: '#000'
},
containerList: {
    alignItems: 'center',
    
},
flatItemRow: {
    borderRadius: 20,
    borderColor: '#000',
    borderWidth: 2,
    width: 350,
    height: 140,
    padding: 10,
    marginBottom: 90,
    justifyContent:'center'

},
flatItemContentRow:{
    flexDirection: 'row',
    justifyContent: 'space-evenly',
    

},

itemTitle: {
    fontWeight: 'bold',
    color: '#000'
    
}
})