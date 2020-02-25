import React,{Component} from 'react';


export default class AddNewProp extends Component{
    constructor(props){
        super(props);
        this.state = {
            namePropAdd:'',
            htmlName:'',
            propUnitsPropAdd:'',
            typePropAdd:-1,
            subID:-1,
            descrPropAdd:'',
            isHidden:true,
            types:[]
        }
        //AddProp
    }
    componentDidMount(){
        
    }
    
    componentDidUpdate(prevProps){
        if(this.props.show!==prevProps.show){
            this.setState({
                isHidden:false

                })
            }
            
        }
    
    handleChangenamePropAdd = (event) => {
        this.setState({
            namePropAdd:event.target.value
        });
    }
    handleChangehtmlName = (event) => {
        this.setState({
            htmlName:event.target.value
        });
    }
    handleChangepropUnitsPropAdd = (event) => {
        this.setState({
            propUnitsPropAdd:+(event.target.value)
        });
    }
    handleChangetypePropAdd = (event) =>{
        this.setState({
            typePropAdd:event.target.value
        })
    }
    handleChangedescrPropAdd = (event) =>{
        this.setState({
            descrPropAdd:event.target.value
        })
    }
    handleSubmit = (event) => {
        fetch(`https://localhost:5001/AddSub?
        htmlNameSubAdd=${this.state.subName}
        &categoryIdSubAdd=${+(this.state.subCategory)}
        &nameSubAdd=${this.state.subName}
        &descrSubAdd=${this.state.subDescr}`,{
            method:"GET",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
              },
            
        }).then(()=>{
            
            this.setState({
                isHidden:true,
            })
        }).catch(err=>{
            console.log(err);           
        }).finally( ()=>{
            event.preventDefault();
        })
        
    }
    handleClose = () =>{
        this.setState({isHidden:true})
    }
    
    
    render(){
       if(!this.state.isHidden){ return(
            <div className="AddPanel">
            <div className="AddPanel-black"></div>
            <div className="AddPanel-form container">
            <i onClick={this.handleClose} className="material-icons small AddPanel-button">close</i>
                <form onSubmit={this.handleSubmit} className="col s12">
                <h6>Введите новый материал</h6>
                <div className="row">
                    <div className="input-field col s12">
                    <input onChange={this.handleChangeSubName} value={this.state.subName}  type="text" className="validate"/>
                    <label htmlFor="subName">Название</label>
                    </div>
                </div>
                <div className="row">       
                    <div className="input-field col s12">
                    <textarea onChange={this.handleChangeSubDescr} value={this.state.subDescr} className="materialize-textarea"></textarea>
                    <label htmlFor="subDescr">Описание</label>
                    </div>  
                </div>
                <div className="row">
                    <div className="input-field col s12">
                    <select className="browser-default" onChange={this.handleChangeSubCategory} value={this.state.subCategory}>
                        {this.state.categories.map(category =>{
                            return (
                                <option value={category.id} key={category.id}>{category.name}</option>
                            )
                        })}
                        
                    </select>
                    
                    </div>
                </div>
                
                <input className="waves-effect waves-light btn-small" type="submit" value="Добавить" />
                </form>
            </div>
            </div>
        )
    }else return null;
    }
}