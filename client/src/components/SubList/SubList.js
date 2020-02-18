import React,{Component} from 'react';
import Sub from '../Sub/Sub';

export default class SubList extends Component{
    constructor(props){
        super(props);
        
        this.state = {
          subs:[],      
        }
        this.getProps = this.getProps.bind(this);
    }
    componentDidMount(){
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
    getProps(propId){
        this.props.getProps(propId);
    }
    
    render(){
        return(
            <section className="col s3 SubList" >
             <ul className="collection with-header">
            <li className="collection-header"><h4 >Выберите вещество</h4></li>
           
           
                {this.state.subs.map(sub=>{
                    
                    return  <Sub id={sub.id} categoryID={sub.categoryID} descr={sub.descr} getProps={this.getProps} key={sub.id} name={sub.name}/>
                })}
            
            
            </ul>
            <a className="btn-floating btn-large waves-effect waves-light red accent-4 SubList-button"><i className="material-icons">add</i></a>
            </section>
        )
    }
}