import React,{Component} from 'react';
import SubInfo from '../SubInfo/SubInfo';
import PropInfo from '../PropInfo/PropInfo';



export default class Info extends Component{
    render(){
        if(this.props.subInfo.length!==0){
            return(
                <div className='Info col s6'>
                    <SubInfo info = {this.props.subInfo}/>
                </div>
            )
        }else if(this.props.propInfo.length!==0){
            
            return(
                <div className='Info col s6'>
                    <PropInfo info = {this.props.propInfo}/>
                </div>
            )
        }else{
            return(
                <div className="Info col s6"></div>
            )
        }
        
    }
}