//using microsoft.aspnetcore.mvc;
//using microsoft.extensions.logging;
//using system;
//using system.collections.generic;
//using system.diagnostics;
//using system.linq;
//using system.threading.tasks;
//using uber.models;

//namespace uber.controllers
//{
//    public class accountcontroller : controller
//    {

//        private readonly usermanager<eshopapplicationuser> usermanager;
//        private readonly signinmanager<eshopapplicationuser> signinmanager;
//        public accountcontroller(usermanager<eshopapplicationuser> usermanager, signinmanager<eshopapplicationuser> signinmanager)
//        {

//            this.usermanager = usermanager;
//            this.signinmanager = signinmanager;
//        }

//        public iactionresult register()
//        {
//            userregistrationdto model = new userregistrationdto();
//            return view(model);
//        }

//        [httppost, allowanonymous]
//        public async task<iactionresult> register(userregistrationdto request)
//        {
//            if (modelstate.isvalid)
//            {
//                var usercheck = await usermanager.findbyemailasync(request.email);
//                if (usercheck == null)
//                {
//                    var user = new eshopapplicationuser
//                    {
//                        username = request.email,
//                        normalizedusername = request.email,
//                        email = request.email,
//                        emailconfirmed = true,
//                        phonenumberconfirmed = true,
//                        usercart = new shoppingcart()
//                    };
//                    var result = await usermanager.createasync(user, request.password);
//                    if (result.succeeded)
//                    {
//                        return redirecttoaction("login");
//                    }
//                    else
//                    {
//                        if (result.errors.count() > 0)
//                        {
//                            foreach (var error in result.errors)
//                            {
//                                modelstate.addmodelerror("message", error.description);
//                            }
//                        }
//                        return view(request);
//                    }
//                }
//                else
//                {
//                    modelstate.addmodelerror("message", "email already exists.");
//                    return view(request);
//                }
//            }
//            return view(request);

//        }

//        [httpget]
//        [allowanonymous]
//        public iactionresult login()
//        {
//            userlogindto model = new userlogindto();
//            return view(model);
//        }

//        [httppost]
//        [allowanonymous]
//        public async task<iactionresult> login(userlogindto model)
//        {
//            if (modelstate.isvalid)
//            {
//                var user = await usermanager.findbyemailasync(model.email);
//                if (user != null && !user.emailconfirmed)
//                {
//                    modelstate.addmodelerror("message", "email not confirmed yet");
//                    return view(model);

//                }
//                if (await usermanager.checkpasswordasync(user, model.password) == false)
//                {
//                    modelstate.addmodelerror("message", "invalid credentials");
//                    return view(model);

//                }

//                var result = await signinmanager.passwordsigninasync(model.email, model.password, model.rememberme, true);

//                if (result.succeeded)
//                {
//                    await usermanager.addclaimasync(user, new claim("userrole", "admin"));
//                    return redirecttoaction("index", "home");
//                }
//                else if (result.islockedout)
//                {
//                    return view("accountlocked");
//                }
//                else
//                {
//                    modelstate.addmodelerror("message", "invalid login attempt");
//                    return view(model);
//                }
//            }
//            return view(model);
//        }


//        public async task<iactionresult> logout()
//        {
//            await signinmanager.signoutasync();
//            return redirecttoaction("login", "account");
//        }
//    }
//}