import React,{Component} from 'react';
import Prop from '../Prop/Prop';

export default class PropsList extends Component{

    constructor(props){
        super(props);
        this.state = {
            props:[]
        }
        this.getValues = this.getValues.bind(this);
    }
    getValues(propSubId){
        this.props.getValues(propSubId);
    }
    
    render(){
        return(
            <section className="col s3 PropsList" >
             <ul className="collection with-header">
            <li className="collection-header"><h4 >Свойства</h4></li>
           
           
            {this.props.subProps.map(prop=>{
                    return <Prop
                    getValues={this.getValues}
                    key={prop.id}
                    descr={prop.descr} 
                    name={prop.name}
                    propUnits = {prop.propUnits}
                    type = {prop.type} />
                })}
            
            
            </ul>
            <a className="btn-floating btn-large waves-effect waves-light red accent-4 SubList-button"><i className="material-icons">add</i></a>
            </section>
            
        )
    }
}