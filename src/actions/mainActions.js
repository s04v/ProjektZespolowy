import { mainTypes } from '../reducers/constants';

const switchTab = () => {
    return (dispatch) => {
        dispatch({
            type: mainTypes.switchTab
        });
    }
}

const setError = (flag) => {
    return (dispatch) => {
        dispatch({
            type: mainTypes.setError,
            payload: { isError: flag }
        });
    }
}

const setErrorText = (text) => {
    return (dispatch) => {
        dispatch({
            type: mainTypes.setError,
            payload: { errorText: text }
        });
    }
}

export {
    switchTab,
    setError,
    setErrorText
}