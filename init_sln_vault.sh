sleep 3 &&
# Solution vault     
curl -v -X POST http://vault:8300/v1/secret/data/sln-vault \
    --header "X-Vault-Token: root" \
    --data-binary @- << EOF
    {
    	"data": {
    		"sln-only-secret": "This is a solution only secret",
    		"org-sln-secret": "This is a secret that exists in org and sln and this is the solution value",
    		"org-sln-user-secret": "This is a secret that exists in org, sln and user and this is the solution value"
    	}	
    }
    EOF

