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
let propSubs = [{
    "Id":"0",
    "PropId":"0",
    "SubstId":"0"
},
{
    "Id":"1",
    "PropId":"0",
    "SubstId":"1"
},
{
    "Id":"2",
    "PropId":"1",
    "SubstId":"0"
},
{
    "Id":"3",
    "PropId":"1",
    "SubstId":"1"
}]
let props = [{
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
}]
let Array1DPropValues = [{
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
}]
let states = [{
    "Id":"0",
    "Name":"NamePState",
    "Descr":"DescrAwrtqere",
    "PropUnits":"Unit",
}]
// let data =  [{
//     "Id":"0",
//     "Name":"NameOfSub",
//     "Descr":"DescrSub",
//     "Props":[
//         {
//             "Id":"0",
//             "Name":"NameProp",
//             "Descr":"DescrProp",
//             "PropUnits":"Unit",
//             "Value":{
//                 "Id":"0",
//                 "PropSubId":"0",
//                 "State":{
//                     "Id":"0",
//                     "Name":"NameState",
//                     "Descr":"DescrState",
//                 },
//                 "Values":[
//                     [0,1,2],
//                     [3,4,5]
//                 ]
//             }
//         }
//     ]
// },
// {
//     "Id":"1",
//     "Name":"NameOfSub1",
//     "Descr":"DescrSub1",
//     "Props":[
//         {
//             "Id":"1",
//             "Name":"NameProp2",
//             "Descr":"DescrProp",
//             "PropUnits":"Unit",
//             "Value":{
//                 "Id":"23423",
//                 "PropSubId":"23434",
//                 "State":{
//                     "Id":"0",
//                     "Name":"NameState",
//                     "Descr":"DescrState",
//                 },
//                 "Values":[
//                     [0,1,2],
//                     [3,4,5]
//                 ]
//             }
//         }
//     ]
// }]
let data = {
    "subs":subs,
    "propSubs":propSubs,
    "props":props,
    "Array1DPropValues":Array1DPropValues,
    "states":states
}
export default data;