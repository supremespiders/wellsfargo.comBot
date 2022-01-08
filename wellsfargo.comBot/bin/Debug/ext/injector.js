let username='dkwfadmin';
let password='dkWFADMIN-321';

var login = async function () {
    try{
        let w=await Get("//span[text()='Welcome']",10);
        if(w!==null)
        {
            return;
        }
        getElementByXpath("//input[@id='userid']").value=username;
        getElementByXpath("//input[@id='password']").value=password;
        getElementByXpath("//input[@id='btnSignon']").click();
        let welcome=await Get("//span[text()='Welcome']",10);
        if(welcome!==null)
            console.log("logged in");
    }catch (e) {
     console.log(e);
    }


}



console.log("injected : "+window.location.href);
login();


function getElementByXpath(path, parent = null) {
    return document.evaluate(path, parent || document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;
}

function getElementsByXPath(xpath, parent = null) {
    let results = [];
    let query = document.evaluate(xpath, parent || document,
        null, XPathResult.ORDERED_NODE_SNAPSHOT_TYPE, null);
    for (let i = 0, length = query.snapshotLength; i < length; ++i) {
        results.push(query.snapshotItem(i));
    }
    return results;
}

async function Get(path,t) {
    var i = 0;
    while (true) {
        const node = getElementByXpath(path);
        if (node) {
            console.log(path + " " + i)
            return node;
        }
        i++;
        if (i == t*2)
            return null;
        await new Promise(r => setTimeout(r, 500));
    }
}
