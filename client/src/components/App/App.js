import React,{Component} from 'react';
import SubList from '../SubList/SubList';
import PropsList from '../PropsList/PropsList';
import Info from '../Info/Info';
import Values from '../Values/Values';
import Header from '../Header/Header';
import AddPanel from '../AddPanel/AddPanel';


class App extends Component{
  constructor(props){
    super(props);
    this.getProps = this.getProps.bind(this);
    this.getValues = this.getValues.bind(this);
    this.state = {
      //array of sub's props for propsList
      subProps:[],
      //info about current sub
      info:[],
      //array of values
      values:[],
      showInfoAndProps:false,

    }
  }

  getValues(propSubId){

    this.setState({
      
      values:[{
        "Id":"0",
        "PropSubId":"0",
        "StateId":"0",
        "State":"123",
        "Value":"12332"
    },
    {
        "Id":"1",
        "PropSubId":"1",
        "StateId":"0",
        "State":"123",
        "Value":"12332"
    },{
        "Id":"2",
        "PropSubId":"2",
        "StateId":"0",
        "State":"123",
        "Value":"12332"
    },
    {
        "Id":"3",
        "PropSubId":"3",
        "StateId":"0",
        "State":"123",
        "Value":"12332"
    }],
    info:{
      "Id":"0",
      "Name":"NameProp",
      "Descr":"DescrProp",
      "PropUnits":"Unit",
    },  
    },()=>{
      document.getElementsByClassName('Values')[0].classList.add('visible');
    })
    
  }

  getProps(subId){
    
    
    this.setState({
      subProps: [{
        "Id":"0",
        "Name":"NameProp",
        "Descr":"DescrProp",
        "PropUnits":"Unit",
    },
    {
        "Id":"1",
        "Name":"Some another props",
        "Descr":"Another props",
        "PropUnits":"Unit23",
    }],
      info:{
        "Id":"0",
        "Name":"NameOfSub",
        "Descr":"DescrSub",
      },
      showInfoAndProps:this.state.info===null?false:true
    },()=>{
      if(this.state.showInfoAndProps === true){
        document.getElementsByClassName('Info')[0].classList.add('visible');
        document.getElementsByClassName('PropsList')[0].classList.add('visible');
      }
    });
    
    
  }
  render(){
    
      return(   
        <div>
          <Header/>
            
              <div className="row">
                <article className="container">
                  <SubList getProps={this.getProps}/>
                  <PropsList getValues={this.getValues} subProps={this.state.subProps}/>
                  
                </article>
          
                <Info info={this.state.info}/>
              </div>
              <Values/>
        {/* <AddPanel/> */}
        </div>
        
      )
    
    
  }
}

export default App;