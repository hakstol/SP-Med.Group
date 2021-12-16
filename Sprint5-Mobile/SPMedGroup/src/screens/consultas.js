import React, { Component } from 'react';

import { 
    View, 
    Text, 
    StyleSheet, 
    Image,
    FlatList 
} from 'react-native';

import AsyncStorage from '@react-native-async-storage/async-storage';

import api from '../services/api';

export default class Consultas extends Component{
  constructor(props) {
    super(props);
    this.state = {
        listarMinhas: []
    };
}

buscarConsulta = async () => {
    try {
        const token = await AsyncStorage.getItem('userToken');

        const resposta = await api.get('/Consultas/Listar/Minhas', {
            headers: {
                Authorization: 'Bearer ' + token
            }
        });

        if (resposta.status == 200) {
                const ListaDasConsultas = resposta.data.listarMinhas;
                this.setState({ listarMinhas : ListaDasConsultas });
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
        //   <View style={styles.main}>
        //     <View style={styles.header}>
        //     <Image source={require('../../assets/img/logo.png')}
        //     style={styles.headerImg}/>
        //     </View>
        //     <View style={styles.section1}>
        //         <Text style={styles.text1}>Consultas agendadas</Text>
        //         <View style={styles.line1}></View>
        //         <Text style={styles.text3}> Data - Especialidade - Paciente</Text>
        //     </View>
        //     <View style={styles.section2}>
        //         <Text style={styles.text2}>Consultas realizadas</Text>
        //         <View style={styles.line2}></View>
        //         <Text style={styles.text4}> Data - Especialidade - Paciente</Text>
        //     </View>

        <View style={styles.main}>
          <View style={styles.header}>
          <Image source={require('../../assets/img/logo.png')}
          style={styles.headerImg}/>
        </View>

        <View style={styles.containerList}>
            <FlatList
                contentContainerStyle={styles.mainBodyList}
                data={this.state.listarMinhas}
                keyExtractor={item => item.IdConsulta}
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
          <Text style={styles.flatItemContent}>{item.IdPacienteNavigation.nomeUsuario}</Text>
      </View>

      <View style={styles.flatItemContentRow}>
          <Text style={styles.itemTitle}>Nome do Médico:</Text>
          <Text style={styles.flatItemContent}>{item.IdMedicoNavigation.NomeMedico}</Text>
      </View>

      <View style={styles.flatItemContentRow}>
          <Text style={styles.itemTitle}>Data da Consulta:</Text>
          <Text style={styles.flatItemContent}>{Intl.DateTimeFormat("pt-BR",{
              year: 'numeric', month: 'short', day: 'numeric', hour: 'numeric', minute: 'numeric'
          }).format(new Date(item.dataConsulta))}</Text>
      </View>
      <View style={styles.flatItemContentRow}>
          <Text style={styles.itemTitle}>Descrição da Consulta:</Text>
          <Text style={styles.flatItemContent}>{item.nomeSituacao}</Text>
      </View>
      
  </View>
)
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
     borderColor: '#1AD9A3',
     alignItems: 'center',
     justifyContent: 'center'
   },

   headerImg: {
     height: 50,
     width: 50,
   },

   //section1
   section1: {
     height: 250,
     width: 360,
     marginTop: 100,
     marginLeft: 10,
   },

   text1: {
     fontSize: 25,
     fontFamily: 'Open Sans Light',
     color: 'black',
   },

   line1: {
     width: 360,
     marginTop: 10,
     borderBottomWidth: 2,
     borderBottomColor: '#1AD9A3',
   },

   text3: {
     paddingTop: 15,
     paddingLeft: 5,
     fontSize: 15,
     letterSpacing: 2,
     fontFamily: 'Open Sans Light'
   },

   //section 2
   section2: {
     height: 250,
     width: 360,
     marginTop: 10,
     marginLeft: 10
   },

   text2: {
   fontSize: 25,
   fontFamily: 'Open Sans Light',
   color: 'black'
   },

   line2: {
   width: 360,
   marginTop: 10,
   borderBottomWidth: 2,
   borderBottomColor: '#1AD9A3'
   },

   text4: {
   paddingTop: 15,
  paddingLeft: 5,
  fontSize: 15,
  letterSpacing: 2,
 fontFamily: 'Open Sans Light'
  },

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
    justifyContent: 'space-evenly'    

},

itemTitle: {
    fontWeight: 'bold',
    color: '#000'
    
}
})