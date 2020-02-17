import React,{Component} from 'react';
import SubList from '../SubList/SubList';
import PropsList from '../PropsList/PropsList';
import Info from '../Info/Info';

export default class DefaultPage extends Component{
    
    render(){
        return( 
           <article className="DefaultPage">
               <SubList subs={this.props.subs}/>
               <PropsList/>
               <Info/>
           </article>                          
        )
    }
}