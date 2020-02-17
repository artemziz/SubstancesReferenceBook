import React,{Component} from 'react';
import Sub from '../Sub/Sub';

export default class SubList extends Component{
    constructor(props){
        super(props);
        let subs = [{
            "Id":"0",
            "Name":"NameOfSub",
            "Descr":"DescrSub",
        },
        {
            "Id":"1",
            "Name":"NameOfSub1",
            "Descr":"DescrSub1",
        }]
        this.state = {
          subs:subs.map((sub)=>{
            return {
              Id:sub['Id'],
              Name:sub['Name'],
            } 
            }),         
        }
        this.getProps = this.getProps.bind(this);
    }
    getProps(propId){
        this.props.getProps(propId);
    }
    
    render(){
        return(
            <section className="col s3 SubList" >
             <ul className="collection with-header">
            <li className="collection-header"><h4 >Выберите вещество</h4></li>
           
           
                {this.state.subs.map(sub=>{
                    
                    return  <Sub Id={sub.Id} getProps={this.getProps} key={sub.Id} name={sub.Name}/>
                })}
            
            
            </ul>
            <a className="btn-floating btn-large waves-effect waves-light red accent-4 SubList-button"><i className="material-icons">add</i></a>
            </section>
        )
    }
}