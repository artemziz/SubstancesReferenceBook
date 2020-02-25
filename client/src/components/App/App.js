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
      subs:[],
      //array of sub's props for propsList
      subProps:[],
      //info about current sub
      subInfo:[],
      //array of values
      propInfo:[],
      values:[],
      showInfoAndProps:false,
      showAddPanel:false,
      addNewProp:false

      


    }
  }
  loadSubs =() =>{
    fetch('https://localhost:5001/substances')
    .then(data => {          
        
        return data.json(); 

    }).then(subs => {     
                
        this.setState({
            subs:subs
        })

    }).catch(err => {

        console.log(err);  

    })
  }
  componentDidMount(){
    this.loadSubs();
}
deleteSub = (subId) =>{
  fetch(`https://localhost:5001/DelSubst?Id=${subId}`)
  .then(()=>{
    this.loadSubs();
  })
  
  .catch(err=>{
      console.log(err);
      
  })
}

  getValues(propSubId){
    
      this.state.subProps.forEach(subProp =>{
        if(subProp['id']===propSubId){
          if(subProp['prop']['type']===1){
            fetch(`https://localhost:5001/Array?propSubID=${propSubId}`)
            .then(res =>{
              return res.json();
            })
            .then(data =>{
              this.setState({
                values:data.map(elem =>{
                  return elem.values
                }),
                propInfo:[subProp,data],
                subInfo:[],
              },()=>{
                  document.getElementsByClassName('Values')[0].classList.add('visible');
                })
              
            })
            .catch(err=>{
              console.log(err);
              
            })
            
            
          } else if(subProp['prop']['type']===2){
              fetch(`https://localhost:5001/assoc?propSubID=${propSubId}`)
              .then(res =>{
                return res.json();
              })
              .then(data =>{
                this.setState({
                  values:data[0].values,
                  propInfo:[subProp,data]
                },()=>{
                    document.getElementsByClassName('Values')[0].classList.add('visible');
                  })
                
              })
              .catch(err=>{
                console.log(err);
                
              })
          } else if(subProp['prop']['type']===3){
              fetch(`https://localhost:5001/scalar?propSubID=${propSubId}`)
                .then(res =>{
                  return res.json();
                })
                .then(data =>{
                  this.setState({
                    values:data[0].values,
                    propInfo:[subProp,data]
                  },()=>{
                      document.getElementsByClassName('Values')[0].classList.add('visible');
                    })
                  
                })
                .catch(err=>{
                  console.log(err);
                  
                })
          }else{
            console.log("error");
            
          }
        }
      })
    
    

    // this.setState({
      
    //   values:[{
    //     "Id":"0",
    //     "PropSubId":"0",
    //     "StateId":"0",
    //     "State":"123",
    //     "Value":"12332"
    // },
    // {
    //     "Id":"1",
    //     "PropSubId":"1",
    //     "StateId":"0",
    //     "State":"123",
    //     "Value":"12332"
    // },{
    //     "Id":"2",
    //     "PropSubId":"2",
    //     "StateId":"0",
    //     "State":"123",
    //     "Value":"12332"
    // },
    // {
    //     "Id":"3",
    //     "PropSubId":"3",
    //     "StateId":"0",
    //     "State":"123",
    //     "Value":"12332"
    // }],
    // info:{
    //   "Id":"0",
    //   "Name":"NameProp",
    //   "Descr":"DescrProp",
    //   "PropUnits":"Unit",
    // },  
    // },()=>{
    //   document.getElementsByClassName('Values')[0].classList.add('visible');
    // })
    
  }
  
  getProps(subId){
    let info = {};
    this.state.subs.forEach(sub=>{
      if(sub['id']===subId){
        info = sub;
        console.log(info);
        
      }
    })
    fetch(`https://localhost:5001/properties?subId=${subId}`)
    .then(data=>{
      return data.json();
    }).then(props=>{
      
      
      this.setState({
        subProps:props,
        subInfo:info,
        propInfo:[],
        showInfoAndProps:this.state.info===null?false:true
      },()=>{
        if(this.state.showInfoAndProps === true){
              document.getElementsByClassName('Info')[0].classList.add('visible');
              document.getElementsByClassName('PropsList')[0].classList.add('visible');
            }
      })
    }).catch(err=>{
      console.log(err);
      
    })
    
  
  }

  addSub = () => {
    this.setState({
      showAddPanel:!this.state.showAddPanel
    })
  }
  addNewProp =() =>{
    this.setState({
      addNewProp:!this.state.addNewProp
    })
  }
  render(){
    
      return(  
        
        <div>
        
          <Header/>
          <AddPanel reload={this.loadSubs} show={this.state.showAddPanel}/>
         
          <div className="row">
            <article className="container">
                  <SubList deleteSub={this.deleteSub} addSub={this.addSub} subs={this.state.subs} getProps={this.getProps}/>
                  <PropsList getValues={this.getValues} subProps={this.state.subProps}/>
                  
            </article>
          
            <Info propInfo={this.state.propInfo} subInfo={this.state.subInfo}/>
          </div>
          <Values values = {this.state.values}/>
          
        </div>
        
        
      )
    
    
  }
}

export default App;
