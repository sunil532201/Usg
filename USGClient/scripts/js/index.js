(function(){

	console.log('checkSystemRequirements');
	console.log(JSON.stringify(ZoomMtg.checkSystemRequirements()));

    ZoomMtg.setZoomJSLib('https://jssdk.zoomus.cn/1.7.6/lib', '/av'); // china cdn option 
    
    ZoomMtg.preLoadWasm();
    ZoomMtg.prepareJssdk();
    
    var API_KEY = 'N3yAIOkZT4uYIL-tQEgQjQ';
    var API_SECRET = 'ZVkG2r9Q5ue5mR9KNQStyjEPzJgxX16VduqN';

    testTool = window.testTool;

    document.getElementById('join_meeting').addEventListener('click', function(e){
        e.preventDefault();

        var [userName , meetingNumber , passWord = ''] = ((window.location.search || '').split('=')[1] || '').split('-')

        if(!userName || !meetingNumber){
            alert('URL is invalid!')
            return 
        }
        
        var meetConfig = {
            apiKey: API_KEY,
            apiSecret: API_SECRET,
            meetingNumber: parseInt(meetingNumber),
            userName,
            passWord,
            leaveUrl: "https://www.apptomate.co",
            role: 0
        };

        var signature = ZoomMtg.generateSignature({
            meetingNumber: meetConfig.meetingNumber,
            apiKey: meetConfig.apiKey,
            apiSecret: meetConfig.apiSecret,
            role: meetConfig.role,
            success: function(res){
                console.log(res.result);
            }
        });

        ZoomMtg.init({
            leaveUrl: 'http://www.zoom.us',
            isSupportAV: true,
            success: function () {
                ZoomMtg.join(
                    {
                        meetingNumber: meetConfig.meetingNumber,
                        userName: meetConfig.userName,
                        signature: signature,
                        apiKey: meetConfig.apiKey,
                        passWord: meetConfig.passWord,
                        success: function(res){
                            $('#nav-tool').hide();
                            console.log('join meeting success');
                        },
                        error: function(res) {
                            console.log(res);
                        }
                    }
                );
            },
            error: function(res) {
                console.log(res);
            }
        });
    });
})();
