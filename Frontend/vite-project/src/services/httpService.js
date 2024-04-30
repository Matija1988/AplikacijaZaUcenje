import axios from 'axios';
import { AxiosError } from 'axios';
import { App } from '../constants';

export const httpService = axios.create({
    baseURL: App.URL + '/api/v1',
    headers: {'Content-Type': 'application/json; charset=utf-8, access-control-allow-origin'}
});


export async function read(name) {
    return await httpService.get('/', name) 
    .then((res) => {return handleSuccess(res); }).catch((e)=> {return processError(e);})
}






export function handleSuccess(res) {
    if(App.DEV) console.table(res.data);
    return { ok: true, data: res.data};
}


export function handleSuccesfulDelete(res) {
    if(App.DEV) console.table(res.data);
    return {ok: true, data: [generateMassage('Message', res.data)]};
}

export function processError(e) {

    if(!e.response) {
        return { ok: false, data: [generateMassage('Network issue', 'server unresponsive')]};
    }

    if(e.code == AxiosError.ERR_NETWORK) {
        return {ok: false, data: [generateMassage('Network issue', 'Try again later')]};
    }

    switch (e.response.satatus) {

        case 503: 

        return{ok : false, data: [generateMassage('Server issue', e.response.data)]};

        case 400:

        if(typeof(e.response.data.errors) !== 'undefined') {
            return handle400(e.response.data.errors);
        }

        return {ok : false, data: [generateMassage('Data mismatch', e.response.data)] };
    }
    return {ok: false, data: e}   
}

function handle400(e) {
    let message = [];
    for(const key in e) {
        message.push(generateMassage(key, e[key][0]));
    }
    return {ok: false, data: message};
}

function generateMassage(property, message) {
    return {property: property, message: message};
}

export function getAlertMessages(data) {
    let messages = '';
    if(Array.isArray(data)){
        for(const p of data) {
            messages += p.property + ": " + p.message + "\n";
        } 
    } else {
        messages = data;
    }
    return messages;
}







