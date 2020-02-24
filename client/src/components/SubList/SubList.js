import React,{Component} from 'react';
import Sub from '../Sub/Sub';

export default class SubList extends Component{
    constructor(props){
        super(props);
        
        
        this.getProps = this.getProps.bind(this);
    }
    
    getProps(subId){
        this.props.getProps(subId);
    }
    addSub = () =>{
        this.props.addSub();
    }
    render(){
        return(
            <section className="col s3 SubList" >
             <ul className="collection with-header">
            <li className="collection-header"><h4 >Вещества</h4></li>
           
           
                {this.props.subs.map(sub=>{
                    
                    return  <Sub id={sub.id} categoryID={sub.categoryID} descr={sub.descr} getProps={this.getProps} key={sub.id} name={sub.name}/>
                })}
            
            
            </ul>
            <a onClick={this.addSub} className="btn-floating btn-large waves-effect waves-light red accent-4 SubList-button"><i className="material-icons">add</i></a>
            </section>
        )
    }
}