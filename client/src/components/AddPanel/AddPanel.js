import React,{Component} from 'react';


export default class AddPanel extends Component{
    constructor(props){
        super(props);
        this.state = {
            subName:'',
            subDescr:'',
            subCategory:-1,
            categories:[],
            isHidden:true
        }
        
    }
    async componentDidMount(){
        let response = await fetch('https://localhost:5001/categories');
        let data = await response.json();
        this.setState({
            categories:data,
            subCategory:+(data[0].id)
        })
        
    }
    componentDidUpdate(prevProps){
        if(this.props.show!==prevProps.show){
            this.setState({
                isHidden:false

                })
            }
            
        }
    
    handleChangeSubName = (event) => {
        this.setState({
            subName:event.target.value
        });
    }
    handleChangeSubDescr = (event) => {
        this.setState({
            subDescr:event.target.value
        });
    }
    handleChangeSubCategory = (event) => {
        this.setState({
            subCategory:+(event.target.value)
        });
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
        })
        event.preventDefault();
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