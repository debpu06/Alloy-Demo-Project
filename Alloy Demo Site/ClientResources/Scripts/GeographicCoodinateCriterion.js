(function () {
    return {
        createUI: function (namingContainerPrefix, container, settings) {
            this.prototype.createUI.apply(this, arguments);
            
            var showMapButton = new dijit.form.Button({
                id: namingContainerPrefix + 'showMapButton',
                latitude: 0,
                longitude: 0,
                label: 'Select Point',
                onClick: function () {
                    var url = '/GeographicCoordinatePicker?latitude=' + this.attr('latitude') + '&longitude=' + this.attr('longitude');

                    window.open(url, 'targetWindow', 'toolbar=no,location = no,status=no,menubar=no,scrollbars=no,resizable=no,width=600px,height=400px');
                }
            });

            dojo.place(showMapButton.domNode, container);
            
            var setCoordinatesScript = document.createElement('script');
            setCoordinatesScript.type = 'text/javascript';
            setCoordinatesScript.innerHTML =
                `function setCoordinates(latitude, longitude)
                 {
                    var lat = document.getElementById('${namingContainerPrefix}Latitude');
                    lat.value = latitude;
                    var lng = document.getElementById('${namingContainerPrefix}Longitude');
                    lng.value = longitude;
                    
                    dijit.byId('${namingContainerPrefix}showMapButton').attr('latitude', latitude);
                    dijit.byId('${namingContainerPrefix}showMapButton').attr('longitude', longitude);
                  } `;
            document.body.appendChild(setCoordinatesScript);
        },
        uiCreated: function(namingContainer, setting) {
            dijit.byId(namingContainer + 'showMapButton').attr('latitude', document.getElementById(namingContainer + 'Latitude').value);
            dijit.byId(namingContainer + 'showMapButton').attr('longitude', document.getElementById(namingContainer + 'Longitude').value);
        }
    }
})();
